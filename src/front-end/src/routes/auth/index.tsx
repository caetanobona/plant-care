import { Button } from '@/components/ui/button'
import { Checkbox } from '@/components/ui/checkbox'
import { Input } from '@/components/ui/input'
import { Label } from '@/components/ui/label'
import { Tabs, TabsContent, TabsList, TabsTrigger } from '@/components/ui/tabs'
import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/auth/')({
  component: RouteComponent,
})

function RouteComponent() {
  return (
    <div className='flex-1 flex flex-col h-full items-center justify-center'>

      <Tabs defaultValue="sign-in" className="">
        <TabsContent value="sign-in">
          <div className='mb-6 space-y-2'>
            <h1 className='text-2xl font-bold'>Welcome Back</h1>
            <p className='text-gray-500 text-sm'>Sign in to manage your plants and track their growth</p>
          </div>
        </TabsContent>
        <TabsContent value="sign-up">
          <div className='mb-6 space-y-2'>
            <h1 className='text-2xl font-bold'>Create your account</h1>
            <p className='text-gray-500 text-sm'>Join PlantCare to start tracking and caring for your plants</p>
          </div>
        </TabsContent>
        <div className='w-[420px] items-center border border-gray-100 shadow-sm rounded-lg p-6'>
          <TabsList className='bg-gray-100'>
            <TabsTrigger value="sign-in" className='px-12 shadow-none '>Sign in</TabsTrigger>
            <TabsTrigger value="sign-up" className='px-12 shadow-none text-gray-600'>Sign up</TabsTrigger>
          </TabsList>
          <TabsContent value="sign-in" className='space-y-4 pt-6 w-full'>
            <div className='space-y-2'>
              <Label className='text-sm font-medium'>Email</Label>
              <Input className='w-full shadow-none' placeholder='Enter your email'/>
            </div>
            <div className='space-y-2'>
              <div className='flex justify-between'>
                <Label className='text-sm font-medium'>Password</Label>
                <a className='text-xs text-green-500 cursor-pointer hover:underline'>Forgot password?</a>
              </div>
              <Input className='w-full shadow-none' placeholder='Create a password'/>
            </div>
            <div className='flex space-x-1'>
              <Checkbox className='shadow-none'/>
              <Label className='text-xs font-medium'>Remember me</Label>
            </div>
            <Button className='w-full text-sm'>
              Sign in
            </Button>
          </TabsContent>
          <TabsContent value="sign-up" className='space-y-4 pt-6 w-full'>
          <div className='space-y-2'>
              <Label className='text-sm font-medium'>Full name</Label>
              <Input className='w-full shadow-none' placeholder='Enter your name'/>
            </div>
            <div className='space-y-2'>
              <Label className='text-sm font-medium'>Email</Label>
              <Input className='w-full shadow-none' placeholder='Enter your email'/>
            </div>
            <div className='space-y-2'>
              <div className='flex justify-between'>
                <Label className='text-sm font-medium'>Password</Label>
                <a className='text-xs text-green-500 cursor-pointer hover:underline'>Forgot password?</a>
              </div>
              <Input className='w-full shadow-none' placeholder='Create a password'/>
              <p className='text-gray-500 text-xs text-start'>Password must be at least 8 characters long</p>
            </div>
            <Button className='w-full text-sm'>
              Sign in
            </Button>
          </TabsContent>
        </div>
      </Tabs>
      <p className='w-[420px] p-6 text-xs text-gray-500'>
        By continuing, you agree to PlantCare's <span className='text-green-500'>Terms of Service</span> and <span className='text-green-500'>Privacy Policy</span>.
      </p>
    </div>
  )
}
