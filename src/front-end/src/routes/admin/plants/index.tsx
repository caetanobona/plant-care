import { AdminTable } from '@/components/AdminTable'
import { createFileRoute } from '@tanstack/react-router'
import { ColumnDef } from '@tanstack/react-table'

export const Route = createFileRoute('/admin/plants/')({
  component: RouteComponent,
})

export const tableColumns: ColumnDef<Plant>[] = [
  {
    accessorKey: "name",
    header: "Name",
  },
  {
    accessorKey: "species",
    header: "Species",
  },
  {
    accessorKey: "wateringInterval",
    header: "Watering Interval",
  },
  {
    accessorKey: "isActive",
    header: "Active"
  }
]

export type Plant = {
  name: string
  room: string
  species: string
  wateringInterval: number
  nextWatering: string
  isActive: boolean
}

export const plantsMock : Plant[] = [
  {  
    name: "Aloe Vera",  
    room: "Bedroom",
    species: "Aloe barbadensis",  
    wateringInterval: 14,
    nextWatering: "Tomorrow",
    isActive: true  
  },  
  {  
    name: "Snake Plant",  
    room: "Bedroom",
    species: "Sansevieria trifasciata",  
    wateringInterval: 10,  
    nextWatering: "Tomorrow",
    isActive: true  
  },  
  {  
    name: "Peace Lily",  
    room: "Bedroom",
    species: "Spathiphyllum wallisii",  
    wateringInterval: 7,  
    nextWatering: "Today",
    isActive: false  
  },  
  {  
    name: "Spider Plant",  
    room: "Bedroom",
    species: "Chlorophytum comosum",  
    wateringInterval: 5,  
    nextWatering: "Tomorrow",
    isActive: true  
  },  
  {  
    name: "Fiddle Leaf Fig",  
    room: "Bedroom",
    species: "Ficus lyrata",  
    wateringInterval: 8,  
    nextWatering: "Tomorrow",
    isActive: true  
  },  
  {  
    name: "Pothos",  
    room: "Bedroom",
    species: "Epipremnum aureum",  
    wateringInterval: 6,  
    nextWatering: "Today",
    isActive: false  
  },  
  {  
    name: "Rubber Plant",  
    room: "Bedroom",
    species: "Ficus elastica",  
    wateringInterval: 9,  
    nextWatering: "Tomorrow",
    isActive: true  
  },  
  {  
    name: "Jade Plant",  
    room: "Bedroom",
    species: "Crassula ovata",  
    wateringInterval: 12,
    nextWatering: "Tomorrow",  
    isActive: true  
  },  
  {  
    name: "Boston Fern",  
    room: "Bedroom",
    species: "Nephrolepis exaltata",  
    wateringInterval: 4,
    nextWatering: "Next Week",  
    isActive: false  
  },  
  {  
    name: "ZaZa Plant",  
    room: "Bedroom",
    species: "Zamioculcas zamiifolia",  
    wateringInterval: 15,
    nextWatering: "Tomorrow",  
    isActive: true  
  }
]

function RouteComponent() {
  return (
    <div>
      <h1 className='font-bold py-4 mt-4'>Admin Plants View</h1>
      <AdminTable columns={tableColumns} data={plantsMock}/>
    </div>
  )
}
