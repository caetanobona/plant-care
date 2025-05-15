import { AdminTable } from '@/components/ui/admin-table'
import { createFileRoute } from '@tanstack/react-router'
import { ColumnDef } from "@tanstack/react-table"

export const Route = createFileRoute('/admin/users/')({
  component: RouteComponent,
})

export type User = {
  name: string
  email: string
  password: string
  isActive: boolean
}

export const tableColumns: ColumnDef<User>[] = [
  {
    accessorKey: "name",
    header: "Name",
  },
  {
    accessorKey: "email",
    header: "Email",
  },
  {
    accessorKey: "password",
    header: "Password",
  },
  {
    accessorKey: "isActive",
    header: "Active"
  }
]

const usersMock : User[] = [
  {
    name: "Caetano",
    email: "caetano@mail.com",
    password: "password-hash",
    isActive: true
  }
] 

function RouteComponent() {
  return (
    <div>
      <h1>ADM Users View</h1>
      <AdminTable columns={tableColumns} data={usersMock}/>
    </div>
  )
}
