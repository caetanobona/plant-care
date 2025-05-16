import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/_dashboard/_dashboard/plants')({
  component: RouteComponent,
})

function RouteComponent() {
  return <div>Hello "/_dashboard/hidden/plants"!</div>
}
