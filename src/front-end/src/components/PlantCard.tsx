import { Plant } from "@/routes/admin/plants";
import { Button } from "./ui/button";
import { Droplets } from "lucide-react";

export interface PlantCardProps extends Plant {
  name: string, 
  room: string, 
  nextWatering: string,
}

const PlantCard = ({name, room, nextWatering} : PlantCardProps) => {
  return ( 
    <div className="rounded-lg border">
      <div className="w-full h-auto relative flex">
        <img src="src/assets/placeholder.webp"/>
        <Button 
          size="icon"
          className="h-5 w-5 absolute right-1 top-1 bg-gray-50 text-black font-bold items-center cursor-pointer hover:bg-gray-100 pb-2"
        >
          ...
        </Button>
        <Button
          className="absolute bottom-1 right-1 text-gray-50"
        >
          <Droplets className="w-2 h-2 p-0"/>
          <span className="p-0 m-0 text-xs">Water</span>
        </Button>
      </div>
      <div className="pl-4 pb-2 pt-2">
        <div className="text-start pb-2">
          <p className="text-gray-900 font-semibold p-0 m-0">{name}</p>
          <p className="text-gray-500 text-sm p-0 m-0">{room}</p>
        </div>
        <div className="justify-between">
          <p className="flex items-center">
            <Droplets className="w-3 h-3 text-blue-500"/>
            <span className="text-xs pl-1">{nextWatering}</span>
          </p>
        </div>
      </div>

    </div>
   );
}
 
export default PlantCard;