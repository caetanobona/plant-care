import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/admin/users/$id')({
  component: RouteComponent,
})

function RouteComponent() {
  const { id } = Route.useParams()
  return <div>Hello "/users/{id}"!</div>
}
