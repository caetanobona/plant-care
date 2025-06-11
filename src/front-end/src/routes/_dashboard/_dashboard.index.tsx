import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/_dashboard/_dashboard/')({
  component: RouteComponent,
})

function RouteComponent() {
  return (
    <div className='text-start'>Welcome back,
    Emma
    
    Your plants are doing well today!</div>
  ) 
}
