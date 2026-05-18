import { api } from "@/lib/api";

import { Topic } from "@/types/topic";

console.log(process.env.NEXT_PUBLIC_API_URL);

export async function getTopics(): Promise<Topic[]> {
  const response = await api.get("/Topics");

  return response.data;
}
