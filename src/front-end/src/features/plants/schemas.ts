import z from "zod/v4";

export const createPlantSchema = z.object({
  userId: z.number().positive(),
  name: z.string().trim().min(3, "Minimum 3 characters required").max(50, "Maximum 50 characters"),
  species: z.string().trim().min(10, "Minimum 10 characters required").max(120, "Maximum 120 characters"),
  image: z.instanceof(File).nullable().optional(),
  wateringInterval: z.string().min(6, "Fill every value")
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