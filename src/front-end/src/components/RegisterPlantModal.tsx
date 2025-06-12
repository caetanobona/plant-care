import axios from "axios";
import { PlusCircle, Upload, X } from "lucide-react";
import { Dialog, DialogContent, DialogTitle, DialogTrigger } from "./ui/dialog";
import { Button } from "./ui/button";
import { Label } from "./ui/label";
import { Input } from "./ui/input";
import { InputOTP, InputOTPGroup, InputOTPSlot } from "./ui/input-otp";
import { useState } from "react";
import { useMutation } from "@tanstack/react-query";
import { useForm } from "react-hook-form";
import { Form } from "./ui/form";

// interface RegisterPlantModalProps {
//   open: boolean,
//   onOpenChange: (open: boolean) => void
// }

interface PlantFormData {
  userId: number;
  name: string;
  species: string;
  imageHash: string;
  wateringInterval: string;
}

const RegisterPlantModal = () => {
  const form = useForm();
  const [formData, setFormData] = useState({
    name: "",
    species: "",
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const [imagePreview, setImagePreview] = useState<string | null>(null);

  const handleImageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => {
        setImagePreview(reader.result as string);
      };
      reader.readAsDataURL(file);
    }
  };

  const removeImage = () => {
    setImagePreview(null);
    const fileInput = document.getElementById("image") as HTMLInputElement;
    if (fileInput) {
      fileInput.value = "";
    }
  };

  const [wateringInterval, setWateringInterval] = useState<string>("");

  const formatWateringInterval = (value: string) => {
    return `${value[0]}${value[1]}:${value[2]}${value[3]}:${value[4]}${value[5]}`;
  };

  const mutation = useMutation({
    mutationFn: (data: PlantFormData) => {
      return axios.post("http://localhost:5048/api/plants", data);
    },
  });

  const onSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    console.log(`
      name: ${formData.name},
      species: ${formData.species},
      wateringInterval: ${formatWateringInterval(wateringInterval)}
      `);

    mutation.mutate({
      userId: 1, // TODO: Implementar autenticação - usar id do usuario que esta fazendo a requisição
      name: formData.name,
      species: formData.species,
      imageHash: imagePreview ?? "",
      wateringInterval: formatWateringInterval(wateringInterval),
    });
  };

  return (
    <Dialog>
      <DialogTrigger>
        <Button className="bg-green-600">
          <PlusCircle />
          Add Plant
        </Button>
      </DialogTrigger>
      <DialogContent>
        <DialogTitle>Register your plant</DialogTitle>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)}>
            <div className="mt-2 space-y-6">
              <div className="space-y-2">
                <Label>Name</Label>
                <Input
                  id="name"
                  name="name"
                  value={formData.name}
                  onChange={handleChange}
                  required
                />
              </div>
              <div className="space-y-2">
                <Label>
                  Species
                  <span className="text-gray-400 text-xs">
                    (scientific name)
                  </span>
                </Label>
                <Input
                  id="species"
                  name="species"
                  value={formData.species}
                  onChange={handleChange}
                  required
                />
              </div>

              <div className="grid gap-2">
                <Label htmlFor="image">Image</Label>
                <div className="space-y-2">
                  {!imagePreview ? (
                    <div className="border-2 border-dashed border-gray-200 rounded-lg  text-center hover:border-green-300 transition-colors">
                      <input
                        id="image"
                        type="file"
                        accept="image/*"
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
                        src={imagePreview || "/placeholder.svg"}
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
              </div>

              <div className="space-y-2">
                <div>
                  <Label>Watering Interval</Label>
                </div>
                <div className="flex">
                  <InputOTP
                    id="wateringInterval"
                    name="wateringInterval"
                    maxLength={6}
                    pattern="^[0-9]+$"
                    value={wateringInterval}
                    onChange={(value) => setWateringInterval(value)}
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
              </div>
              <div className="w-full text-end space-x-2">
                <Button variant="outline" type="reset">
                  Cancel
                </Button>
                <Button type="submit">Register</Button>
              </div>
            </div>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
};

export default RegisterPlantModal;
