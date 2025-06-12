import {
  CreatePlantRequest,
  createPlantSchema,
  PlantResponse,
  plantResponseSchema,
} from "../schemas";
import axios from "axios";
import { z } from "zod";

const API_BASE_URL = "http://localhost:5048/api";

export const plantsApi = {
  create: async (form: CreatePlantRequest): Promise<PlantResponse> => {
    const validatedData = createPlantSchema.parse(form);

    try {
      const response = await axios.post(
        `${API_BASE_URL}/plants`,
        validatedData
      );

      const parsedResponse = plantResponseSchema.parse(response);
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
