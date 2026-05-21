import { api } from "@/lib/api";

export async function getNewsletterPreview() {
  const response = await api.get("/News/preview");

  return response.data;
}
