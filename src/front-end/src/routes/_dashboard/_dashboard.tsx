import { DashboardSidebar } from '@/components/DashboardSidebar'
import { SidebarProvider, SidebarTrigger } from '@/components/ui/sidebar'
import { createFileRoute, Outlet } from '@tanstack/react-router'

export const Route = createFileRoute('/_dashboard/_dashboard')({
  component: RouteComponent,
})

export function RouteComponent() {
  return (
    <div>
      <SidebarProvider>
        <DashboardSidebar />
        <main>
          <SidebarTrigger />
          <Outlet />
        </main>
      </SidebarProvider>
    </div>
  )
}
