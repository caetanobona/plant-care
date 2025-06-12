import z from "zod";

export const createPlantSchema = z.object({
  userId: z.number().positive(),
  name: z.string().trim().min(1, "Required").max(50, "Maximum 50 characters"),
  species: z.string().trim().min(10, "Minimum 10 characters required"),
  image: z.string().base64url().nullable().optional(),
  wateringInterval: z.string().length(8, `Must be in 00:00:00 format`)
})

export const plantResponseSchema = z.object({
  id: z.number(),
  userId: z.number(),
  name: z.string(),
  species: z.string(),
  imageHash: z.string().nullable(),
  wateringInterval: z.string(),
  lastWatered: z.string().nullable(),
  lightRequirements: z.string().nullable()
})

export type CreatePlantRequest = z.infer<typeof createPlantSchema>
export type PlantResponse = z.infer<typeof plantResponseSchema>