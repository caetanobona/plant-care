import { createFileRoute } from '@tanstack/react-router'
import { plantsMock } from '../admin/plants'
import PlantCard from '@/components/PlantCard'
import RegisterPlantModal from '@/components/RegisterPlantModal'

export const Route = createFileRoute('/_dashboard/_dashboard/plants')({
  component: RouteComponent,
})




function RouteComponent() {
  return (
    <div className='h-screen w-full max-w-screen'>
      <div className='flex w-full justify-between mb-6'>
        <div className='text-start '>
          <h1 className='font-bold text-2xl mb-2'>My Plants</h1>
          <p className='text-gray-600 text-sm'>Manage and monitor your plant collection</p>
        </div>
        <RegisterPlantModal />
      </div>

      <div className='grid gap-4 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4'>
        {plantsMock.map((plant) => (
          <PlantCard {...plant}/>
        ))}
      </div>
    </div>
  )
}
