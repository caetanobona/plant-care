import { createRootRoute, Outlet } from '@tanstack/react-router'

export const Route = createRootRoute({
  component: () => (
    <div className='min-h-screen min-w-screen flex flex-col'>
      <Outlet />
    </div>
  ),
})