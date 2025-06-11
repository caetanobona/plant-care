"use client"

import { CalendarDays, Home, Leaf, LineChart, LogOut, Settings, Sprout, User } from "lucide-react"

import { cn } from "@/lib/utils"

export function DashboardSidebar() {
  const pathname = window.location.href

  return (
      <aside className="w-64 border-r border-gray-100 bg-white hidden md:flex flex-col h-full shrink-0">
        <div className="p-4 flex items-center gap-2 border-b border-gray-100">
          <Leaf className="h-6 w-6 text-green-600" />
          <span className="text-lg font-semibold text-green-600">PlantCare</span>
        </div>
        <nav className="flex-1 p-2 overflow-y-auto">
          <ul className="space-y-1">
            <li>
              <a
                href="/"
                className={cn(
                  "flex items-center gap-3 px-3 py-2 text-sm font-medium rounded-md transition-all",
                  pathname === "/"
                    ? "text-green-600 bg-green-50"
                    : "text-gray-600 hover:text-green-600 hover:bg-green-50",
                )}
              >
                <Home className="h-5 w-5" />
                Dashboard
              </a>
            </li>
            <li>
              <a
                href="/plants"
                className={cn(
                  "flex items-center gap-3 px-3 py-2 text-sm font-medium rounded-md transition-all",
                  pathname === "/plants"
                    ? "text-green-600 bg-green-50"
                    : "text-gray-600 hover:text-green-600 hover:bg-green-50",
                )}
              >
                <Sprout className="h-5 w-5" />
                My Plants
              </a>
            </li>
            <li>
              <a
                href="#"
                className="flex items-center gap-3 px-3 py-2 text-sm font-medium rounded-md text-gray-600 hover:text-green-600 hover:bg-green-50 transition-all"
              >
                <CalendarDays className="h-5 w-5" />
                Care Schedule
              </a>
            </li>
            <li>
              <a
                href="#"
                className="flex items-center gap-3 px-3 py-2 text-sm font-medium rounded-md text-gray-600 hover:text-green-600 hover:bg-green-50 transition-all"
              >
                <LineChart className="h-5 w-5" />
                Plant Health
              </a>
            </li>
            <li>
              <a
                href="#"
                className="flex items-center gap-3 px-3 py-2 text-sm font-medium rounded-md text-gray-600 hover:text-green-600 hover:bg-green-50 transition-all"
              >
                <Settings className="h-5 w-5" />
                Settings
              </a>
            </li>
          </ul>
        </nav>
        <div className="border-t border-gray-100 p-2">
          <ul className="space-y-1">
            <li>
              <a
                href="/auth"
                className="w-full flex items-center gap-3 px-3 py-2 text-sm font-medium rounded-md text-gray-600 hover:text-green-600 hover:bg-green-50 text-left transition-all"
              >
                <User className="h-5 w-5" />
                Profile
              </a>
            </li>
            <li>
              <a
                href="/auth"
                className="flex items-center gap-3 px-3 py-2 text-sm font-medium rounded-md text-gray-600 hover:text-red-600 hover:bg-red-50 transition-all"
              >
                <LogOut className="h-5 w-5"/>
                Logout
              </a>
            </li>
          </ul>
        </div>
      </aside>
  )
}
