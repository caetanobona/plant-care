import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarHeader,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem
} from "@/components/ui/sidebar"
import { Link } from "@tanstack/react-router"

import { Calendar, Home, Leaf } from "lucide-react"

const menuItems = [
  {
    title: "Home",
    url: "/",
    icon: Home,
  },
  {
    title: "Plants",
    url: "/plants",
    icon: Leaf,
  },
  {
    title: "Care Shcedule",
    url: "/care-schedule",
    icon: Calendar,
  }
]

export function DashboardSidebar() {
  return (
    <Sidebar>
      <SidebarHeader className="items-start p-4 border-b-1">
        <p className="flex items-center">
          <Leaf className="w-5 text-green-500"/>
          <span className="text-xl text-green-500 pl-2">PlantCare</span>
        </p>
      </SidebarHeader>
      <SidebarContent>
        <SidebarMenu className="p-2">
          {menuItems.map((item) => (
            <SidebarMenuItem key={item.title} className="hover:bg-green-500">
              <SidebarMenuButton asChild>
                <Link to={item.url}>
                  <item.icon />
                  {item.title}
                </Link>
              </SidebarMenuButton>
            </SidebarMenuItem>
          ))}
        </SidebarMenu>
      </SidebarContent>
      <SidebarFooter>
        Profile
      </SidebarFooter>
    </Sidebar>
  )
}
