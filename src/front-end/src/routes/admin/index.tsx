import { createFileRoute, Link } from '@tanstack/react-router'

export const Route = createFileRoute('/admin/')({
  component: RouteComponent,
})

const adminRoutes = [
  {
    title: 'Users',
    url: '/admin/users',
    description: 'View all registered users'
  },
  {
    title: 'Plants',
    url: '/admin/plants',
    description: 'View all registered plants'
  }
]

function RouteComponent() {
  return (
    <div>
      <h1 className='text-4xl'>Admin Dashboard</h1>
      <div className='w-full h-full grid grid-cols-2 py-4 px-20 mt-6'>
        {adminRoutes.map((route) => (
          <Link to={route.url}>
            <div className='border-1 w-[60%] mx-auto h-[25vh] items-center p-2 hover:font-bold hover:bg-gray-50'>
              <h2 className=' text-2xl'>{route.title}</h2>    
              <p className='font-normal py-2 text-md'>{route.description}</p>  
            </div>
          </Link>
        ))}
      </div>
    </div>
  )
}
