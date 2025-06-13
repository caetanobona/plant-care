import {
  CreatePlantRequest,
  createPlantSchema,
  PlantResponse,
  plantResponseSchema,
} from "../features/plants/schemas";
import axios from "axios";
import { z } from "zod";

const API_BASE_URL = "http://localhost:5048/api";

export const plantsApi = {
  create: async (form: CreatePlantRequest): Promise<PlantResponse> => {
    const validatedData = createPlantSchema.parse(form);

    console.log(`Validated Data NAME: ${validatedData.name}`)
    console.log(`Validated Data SPECIES: ${validatedData.species}`)
    console.log(`Validated Data IMAGE: ${validatedData.image}`)
    console.log(`Validated Data WATERING: ${validatedData.wateringInterval}`)

    const formData = new FormData();
    formData.append("userId", validatedData.userId.toString())
    formData.append("name", validatedData.name)
    formData.append("species", validatedData.species)
    if(validatedData.image) {
      formData.append("image", validatedData.image)
    }
    formData.append("wateringInterval", validatedData.wateringInterval)

    try {
      const response = await axios.post(
        `${API_BASE_URL}/plants`,
        formData,
        {
          headers: {  
            "Content-Type": "multipart/form-data",  
          },
        }
      );

      const parsedResponse = plantResponseSchema.parse(response.data);

      console.log(`parsed response NAME: ${parsedResponse.name}`)
      console.log(`parsed response SPECIES: ${parsedResponse.species}`)
      console.log(`parsed response IMAGE: ${parsedResponse.imageHash}`)
      console.log(`parsed response WATERING: ${parsedResponse.wateringInterval}`)

      return parsedResponse;
    } catch (error) {
      if (error instanceof z.ZodError) {
        console.error("Validation error:", error);
        throw new Error(
          `Validation failed ${error.errors.map((e) => e.message).join(", ")}`
        );
      } else if (axios.isAxiosError(error)) {
        console.error("Axios error", error);
        throw new Error(`API request failed: ${error.message}`);
      } else {
        console.error("Unexpected error", error);
        throw new Error("An unexpected error occurred");
      }
    }
  },
};
