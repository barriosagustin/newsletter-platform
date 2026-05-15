import { api } from "@/lib/api";

import { LoginRequest, RegisterRequest } from "@/types/auth";

export async function login(data: LoginRequest): Promise<string> {
  const response = await api.post("/Auth/login", data);

  return response.data;
}

export async function register(data: RegisterRequest) {
  const response = await api.post("/Auth/register", data);

  return response.data;
}
