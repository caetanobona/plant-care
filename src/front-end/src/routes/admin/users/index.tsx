import { AdminTable } from '@/components/AdminTable'
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
  },
  {  
    name: "Michael Smith",  
    email: "michael.smith@yahoo.com",  
    password: "U%svnBTUJGtd",  
    isActive: true  
  },  
  {  
    name: "Michael Garcia",  
    email: "michael.garcia@hotmail.com",  
    password: "rUucoOz@eFDn",  
    isActive: true  
  },  
  {  
    name: "Mary Jones",  
    email: "mary.jones@hotmail.com",  
    password: "vhcLwYcSEi^@",  
    isActive: true  
  },  
  {  
    name: "Michael Williams",  
    email: "michael.williams@yahoo.com",  
    password: "IgRt*pfkfNhx",  
    isActive: false  
  },  
  {  
    name: "Michael Brown",  
    email: "michael.brown@yahoo.com",  
    password: "DkzJ9%m36WjN",  
    isActive: true  
  },  
  {  
    name: "John Williams",  
    email: "john.williams@yahoo.com",  
    password: "VzViCJCNkthQ",  
    isActive: false  
  },  
  {  
    name: "Mary Miller",  
    email: "mary.miller@gmail.com",  
    password: "kr59Bv7^0YT^",  
    isActive: true  
  },  
  {  
    name: "John Miller",  
    email: "john.miller@yahoo.com",  
    password: "x0biGbTA#Qx!",  
    isActive: true  
  },  
  {  
    name: "Linda Brown",  
    email: "linda.brown@gmail.com",  
    password: "*ZZRMHMM@Ppl",  
    isActive: false  
  },  
  {  
    name: "Patricia Garcia",  
    email: "patricia.garcia@yahoo.com",  
    password: "ETK1FitawVnR",  
    isActive: true  
  },  
  {  
    name: "Mary Brown",  
    email: "mary.brown@hotmail.com",  
    password: "DxARmQilysm9",  
    isActive: true  
  },  
  {  
    name: "Elizabeth Davis",  
    email: "elizabeth.davis@outlook.com",  
    password: "2dXRBj3BPpgQ",  
    isActive: true  
  },  
  {  
    name: "James Brown",  
    email: "james.brown@yahoo.com",  
    password: "nHnHf!jWsDKU",  
    isActive: false  
  },  
  {  
    name: "Michael Garcia",  
    email: "michael.garcia@hotmail.com",  
    password: "*hx5AVKae!V&",  
    isActive: true  
  },  
  {  
    name: "Jennifer Smith",  
    email: "jennifer.smith@gmail.com",  
    password: "3%4dOodJY#ZX",  
    isActive: false  
  },  
  {  
    name: "Jennifer Miller",  
    email: "jennifer.miller@gmail.com",  
    password: "xbo%t5d06g*i",  
    isActive: false  
  },  
  {  
    name: "William Smith",  
    email: "william.smith@hotmail.com",  
    password: "zldvpeV4uPKR",  
    isActive: false  
  },  
  {  
    name: "Patricia Miller",  
    email: "patricia.miller@outlook.com",  
    password: "vrXYJz!#iCaA",  
    isActive: true  
  },  
  {  
    name: "James Davis",  
    email: "james.davis@outlook.com",  
    password: "I#ycPm7!j9Em",  
    isActive: false  
  },  
  {  
    name: "James Miller",  
    email: "james.miller@yahoo.com",  
    password: "tDIG09XtvNI3",  
    isActive: true  
  }
] 

function RouteComponent() {
  return (
    <div>
      <h1 className='font-bold py-4 mt-4'>Admin Users View</h1>
      <AdminTable columns={tableColumns} data={usersMock}/>
    </div>
  )
}
