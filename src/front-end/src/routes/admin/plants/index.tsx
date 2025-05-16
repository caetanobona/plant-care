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

type Plant = {
  name: string
  species: string
  wateringInterval: number
  isActive: boolean
}

const plantsMock : Plant[] = [
  {  
    name: "Aloe Vera",  
    species: "Aloe barbadensis",  
    wateringInterval: 14,  
    isActive: true  
  },  
  {  
    name: "Snake Plant",  
    species: "Sansevieria trifasciata",  
    wateringInterval: 10,  
    isActive: true  
  },  
  {  
    name: "Peace Lily",  
    species: "Spathiphyllum wallisii",  
    wateringInterval: 7,  
    isActive: false  
  },  
  {  
    name: "Spider Plant",  
    species: "Chlorophytum comosum",  
    wateringInterval: 5,  
    isActive: true  
  },  
  {  
    name: "Fiddle Leaf Fig",  
    species: "Ficus lyrata",  
    wateringInterval: 8,  
    isActive: true  
  },  
  {  
    name: "Pothos",  
    species: "Epipremnum aureum",  
    wateringInterval: 6,  
    isActive: false  
  },  
  {  
    name: "Rubber Plant",  
    species: "Ficus elastica",  
    wateringInterval: 9,  
    isActive: true  
  },  
  {  
    name: "Jade Plant",  
    species: "Crassula ovata",  
    wateringInterval: 12,  
    isActive: true  
  },  
  {  
    name: "Boston Fern",  
    species: "Nephrolepis exaltata",  
    wateringInterval: 4,  
    isActive: false  
  },  
  {  
    name: "ZZ Plant",  
    species: "Zamioculcas zamiifolia",  
    wateringInterval: 15,  
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
