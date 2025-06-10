import { PlusCircle } from "lucide-react";
import { Dialog, DialogContent, DialogTitle, DialogTrigger } from "./ui/dialog";
import { Button } from "./ui/button";
import { Label } from "./ui/label";
import { Input } from "./ui/input";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "./ui/select";
import { InputOTP, InputOTPGroup, InputOTPSlot } from "./ui/input-otp";
import { REGEXP_ONLY_DIGITS } from "input-otp";

const DialogRegisterPlant = () => {

  const mockRooms = [
    "Bedroom",
    "Living room",
    "Kitchen"
  ]
  
  const timeTypes = [
    "Seconds",
    "Minutes",
    "Hours",
    "Days"
  ]

  return ( 
    <Dialog>
    <DialogTrigger>
      <Button className='bg-green-600'>
        <PlusCircle />
        Add Plant
      </Button>
    </DialogTrigger>
    <DialogContent>
      <DialogTitle>
        Register your plant
      </DialogTitle>
      <div className='mt-2 space-y-6'>
        <div className='space-y-2'>
          <Label>Name</Label>
          <Input/>
        </div> 
        <div className='space-y-2'>
          <Label>Species <span className='text-gray-400'>(cientific name)</span></Label>
          <Input/>
        </div> 
        <div className='space-y-2'>
          <div>
            <Label>Watering Interval</Label>
          </div>
          
          <div className='flex'>
            <InputOTP 
              maxLength={6}
              pattern={REGEXP_ONLY_DIGITS}
            >
              <div className=" w-auto">
                <span className="text-xs text-gray-600">Days</span>
                <InputOTPGroup>
                  <InputOTPSlot index={0}/>
                  <InputOTPSlot index={1}/>
                </InputOTPGroup>
              </div>
              <span>:</span>
              <div className="">
                <span className="text-xs text-gray-600">Minutes</span>
                <InputOTPGroup>
                  <InputOTPSlot index={2}/>
                  <InputOTPSlot index={3}/>
                </InputOTPGroup>
              </div>
              <span>:</span>
              <div className="">
                <span className="text-xs text-gray-600">Seconds</span>
                <InputOTPGroup>
                  <InputOTPSlot index={4}/>
                  <InputOTPSlot index={5}/>
                </InputOTPGroup>
              </div>

            </InputOTP>
          </div>
        </div> 
        <div className='w-full text-end'>
          <Button>
            Register
          </Button>
        </div>
      </div>
    </DialogContent>
  </Dialog>
   );
}
 
export default DialogRegisterPlant;