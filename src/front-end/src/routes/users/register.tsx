import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/users/register')({
  component: RouteComponent,
})

function RouteComponent() {
  return (
    <div className='flex w-full h-full bg-gray-100 items-center justify-center'>
      <div className=''>
        <h1>Register</h1>
      </div>
    </div>
  )
}
