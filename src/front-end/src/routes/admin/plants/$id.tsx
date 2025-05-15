import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/admin/plants/$id')({
  component: RouteComponent,
})

function RouteComponent() {
  return <div>Hello "/admin/plants/$id"!</div>
}
