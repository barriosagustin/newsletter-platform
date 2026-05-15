import { jwtDecode } from "jwt-decode";

interface JwtPayload {
  exp?: number;
}

export function isAuthenticated() {
  const token = localStorage.getItem("token");

  console.log("TOKEN:", token);

  if (!token) {
    return false;
  }

  try {
    const decoded = jwtDecode<JwtPayload>(token);

    console.log("DECODED:", decoded);

    if (!decoded.exp) {
      return true;
    }

    const currentTime = Date.now() / 1000;

    return decoded.exp > currentTime;
  } catch (error) {
    console.error(error);

    return false;
  }
}
