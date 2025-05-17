import { Button } from '@/components/ui/button'
import { createFileRoute } from '@tanstack/react-router'
import { plantsMock } from '../admin/plants'
import PlantCard from '@/components/PlantCard'
import { PlusCircle } from 'lucide-react'
import { Dialog, DialogContent, DialogTitle, DialogTrigger } from '@/components/ui/dialog'
import { Input } from '@/components/ui/input'
import { Label } from '@/components/ui/label'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from '@/components/ui/select'

export const Route = createFileRoute('/_dashboard/_dashboard/plants')({
  component: RouteComponent,
})

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


function RouteComponent() {
  return (
    <div className='h-screen w-full max-w-screen'>
      <div className='flex w-full justify-between mb-6'>
        <div className='text-start '>
          <h1 className='font-bold text-2xl'>My Plants</h1>
          <p className='text-gray-600 text-sm'>Manage and monitor your plant collection</p>
        </div>

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
                <Label>Watering Interval</Label>
                <div className='flex space-x-4'>
                  <Input/>
                  <Select>
                    <SelectTrigger className="w-[180px]">
                      <SelectValue placeholder="Time" />
                    </SelectTrigger>
                    <SelectContent>
                      {timeTypes.map((time) => (
                        <SelectItem value={time}>{time}</SelectItem>
                      ))}
                    </SelectContent>
                  </Select>
                </div>
              </div> 
              <div className='space-y-2'>
                <Label>Room</Label>
                <Select>
                    <SelectTrigger className="w-[180px]">
                      <SelectValue placeholder="Room" />
                    </SelectTrigger>
                    <SelectContent>
                      {mockRooms.map((room) => (
                        <SelectItem value={room}>{room}</SelectItem>
                      ))}
                    </SelectContent>
                  </Select>
              </div>
              <div className='w-full text-end'>
                <Button>
                  Register
                </Button>
              </div>
            </div>
          </DialogContent>
        </Dialog>

        
      </div>

      <div className='grid gap-4 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4'>
        {plantsMock.map((plant) => (
          <PlantCard {...plant}/>
        ))}
      </div>
    </div>
  )
}
