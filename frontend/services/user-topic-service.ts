import { api } from "@/lib/api";

export async function selectTopic(topicId: number) {
  const response = await api.post("/UserTopics", {
    topicId,
  });

  return response.data;
}

export async function getSelectedTopics() {
  const response = await api.get("/UserTopics");

  return response.data;
}

export async function removeTopic(topicId: number) {
  await api.delete(`/UserTopics/${topicId}`);
}
