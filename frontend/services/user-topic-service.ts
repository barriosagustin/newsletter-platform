import { api } from "@/lib/api";

export async function selectTopic(topicId: number) {
  const response = await api.post("/UserTopics", topicId);

  return response.data;
}
