import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/_dashboard/_dashboard/')({
  component: RouteComponent,
})

function RouteComponent() {
  return (
    <div>Hello "/_dashboard/_dashboard/"!</div>
  ) 
}
