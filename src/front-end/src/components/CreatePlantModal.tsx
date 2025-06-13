import { PlusCircle, Upload, X } from "lucide-react";
import { Dialog, DialogContent, DialogTitle, DialogTrigger } from "./ui/dialog";
import { Button } from "./ui/button";
import { Input } from "./ui/input";
import { InputOTP, InputOTPGroup, InputOTPSlot } from "./ui/input-otp";
import { useRef, useState } from "react";
import { useMutation } from "@tanstack/react-query";
import { useForm } from "react-hook-form";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "./ui/form";
import { z } from "zod/v4";
import { zodResolver } from "@hookform/resolvers/zod";
import { createPlantSchema } from "@/features/plants/schemas";
import { plantsApi } from "@/api/plants";

interface CreatePlantModalProps {
  open : boolean
  onOpenChange : (open: boolean) => void
}

const CreatePlantModal = ({ open, onOpenChange } : CreatePlantModalProps) => {
  const form = useForm<z.infer<typeof createPlantSchema>>({
    resolver: zodResolver(createPlantSchema),
    defaultValues: {
      userId: 1,
      name: "",
      species: "",
      wateringInterval: "",
    },
  });

  const inputRef = useRef<HTMLInputElement>(null);
  const [imagePreview, setImagePreview] = useState<string | null>(null);

  const handleImageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (file) {
      form.setValue("image", file)
      const reader = new FileReader();
      reader.onloadend = () => {
        setImagePreview(reader.result as string)
      }
      reader.readAsDataURL(file);
    }
  };

  const removeImage = () => {
    form.setValue("image", null);
    setImagePreview(null);
    const fileInput = document.getElementById("image") as HTMLInputElement;
    if (fileInput) {
      fileInput.value = "";
    }
  };

  const mutation = useMutation({
    mutationFn: plantsApi.create,
  });

  const formatWateringInterval = (val : string):string => `${val[0]}${val[1]}:${val[2]}${val[3]}:${val[4]}${val[5]}`

  const onSubmit = async (values: z.infer<typeof createPlantSchema>) => {
    const finalValues = {
      ...values,
      wateringInterval: formatWateringInterval(values.wateringInterval)
    };

    console.log(finalValues);
    await mutation.mutate(finalValues);

    onOpenChange(false);
  };

  const onCancel = () => {
    form.reset()
    onOpenChange(false)
  }

  return (
    <Dialog open={open} onOpenChange={onOpenChange}>
      <DialogTrigger>
        <Button className="bg-green-600">
          <PlusCircle />
          Add Plant
        </Button>
      </DialogTrigger>
      <DialogContent>
        <DialogTitle>Register your plant</DialogTitle>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} action="">
            <div className="mt-2 space-y-6">
              <FormField
                control={form.control}
                name="name"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Name</FormLabel>
                    <FormControl>
                      <Input
                        {...field}
                        placeholder="Enter plant name"
                        className="text-sm"
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name="species"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Species</FormLabel>
                    <FormControl>
                      <Input
                        {...field}
                        placeholder="Enter plant species"
                        className="text-sm"
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name="image"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Image</FormLabel>
                    <div className="space-y-2">
                      {!field.value ? (
                        <div className="border-2 border-dashed border-gray-200 rounded-lg  text-center hover:border-green-300 transition-colors">
                          <input
                            ref={inputRef}
                            id="image"
                            type="file"
                            accept=".jpg, .png, .jpeg, .svg"
                            onChange={handleImageChange}
                            className="hidden"
                          />
                          <label htmlFor="image" className="cursor-pointer">
                            <div className="py-6">
                              <Upload className="h-8 w-8 text-gray-400 mx-auto mb-2" />
                              <p className="text-sm text-gray-600">
                                Click to upload an image
                              </p>
                              <p className="text-xs text-gray-400 mt-1">
                                PNG, JPG, GIF up to 5MB
                              </p>
                            </div>
                          </label>
                        </div>
                      ) : (
                        <div className="relative">
                          <img
                            src={imagePreview!}
                            alt="Plant preview"
                            className="w-full h-32 object-cover rounded-lg border border-gray-200"
                          />
                          <Button
                            type="button"
                            variant="ghost"
                            size="icon"
                            className="absolute cursor-pointer top-2 right-2 h-6 w-6 bg-white/80 backdrop-blur-sm hover:bg-white"
                            onClick={removeImage}
                          >
                            <X className="h-4 w-4" />
                            <span className="sr-only">Remove image</span>
                          </Button>
                        </div>
                      )}
                    </div>
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name="wateringInterval"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Watering Interval</FormLabel>
                    <div className="flex">
                      <InputOTP
                        {...field}
                        maxLength={6}
                        pattern="^[0-9]+$"
                        required
                      >
                        <div className="w-auto">
                          <span className="text-xs text-gray-600">Days</span>
                          <InputOTPGroup>
                            <InputOTPSlot index={0} />
                            <InputOTPSlot index={1} />
                          </InputOTPGroup>
                        </div>
                        <span className="mt-4">:</span>
                        <div>
                          <span className="text-xs text-gray-600">Hours</span>
                          <InputOTPGroup>
                            <InputOTPSlot index={2} />
                            <InputOTPSlot index={3} />
                          </InputOTPGroup>
                        </div>
                        <span className="mt-4">:</span>
                        <div>
                          <span className="text-xs text-gray-600">Minutes</span>
                          <InputOTPGroup>
                            <InputOTPSlot index={4} />
                            <InputOTPSlot index={5} />
                          </InputOTPGroup>
                        </div>
                      </InputOTP>
                    </div>
                    <FormMessage />
                  </FormItem>
                )}
              />
            </div>
            <div className="w-full text-end space-x-2">
              <Button variant="outline" type="reset" onClick={onCancel}>
                Cancel
              </Button>
              <Button type="submit" className="cursor-pointer">
                Register
              </Button>
            </div>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
};

export default CreatePlantModal;
