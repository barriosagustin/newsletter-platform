import { api } from "@/lib/api";

export async function getCurrentUser() {
  const response = await api.get("/Users/me");

  return response.data;
}

export async function updateNewsletterSettings(data: {
  newsletterEnabled: boolean;
  newsletterFrequency: string;
}) {
  const response = await api.put("/Users/newsletter-settings", data);

  return response.data;
}
