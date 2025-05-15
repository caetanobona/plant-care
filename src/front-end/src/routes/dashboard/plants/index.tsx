import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/dashboard/plants/')({
  component: RouteComponent,
})

function RouteComponent() {
  return <div>Hello "/dashboard/plants/"!</div>
}
