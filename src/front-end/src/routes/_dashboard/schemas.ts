import z from "zod";

export const registerPlantSchema = z.object({
  name: z.string().trim().min(1, "Required").max(50, "Maximum 50 characters"),
  species: z.string().trim().min(10, "Minimum 10 characters required"),
  imageHash: z.string().base64url(),
  wateringInterval: z.string().length(10, `Must be in 00:00:00 format`)
})