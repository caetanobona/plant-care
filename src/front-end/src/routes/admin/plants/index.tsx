import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/admin/plants/')({
  component: RouteComponent,
})

type Plant = {
  name: string
  species: string
  wateringInterval: number
}

function RouteComponent() {
  return (
    <div>
      <h1>ADM Plants View</h1>
    </div>
  )
}
