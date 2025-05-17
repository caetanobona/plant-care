import { DashboardSidebar } from '@/components/DashboardSidebar'
import { SidebarProvider } from '@/components/ui/sidebar'
import { createFileRoute, Outlet } from '@tanstack/react-router'

export const Route = createFileRoute('/_dashboard/_dashboard')({
  component: RouteComponent,
})

export function RouteComponent() {
  return (
    <div className='flex w-full h-full'>
      <SidebarProvider>
      <DashboardSidebar />
        <div className="mx-auto flex-1 max-w-screen-2xl h-full">
          <main className='h-full flex flex-col'>
            <Outlet />
          </main>
        </div>
      </SidebarProvider>
    </div>

  )
}
