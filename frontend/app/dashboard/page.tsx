"use client";

import { useEffect } from "react";
import { useRouter } from "next/navigation";

import { isAuthenticated } from "@/lib/auth";

export default function DashboardPage() {
  const router = useRouter();

  useEffect(() => {
    const authenticated = isAuthenticated();

    if (!authenticated) {
      router.push("/login");
    }
  }, [router]);

  return (
    <main className="min-h-screen bg-black text-white p-8">
      <div className="max-w-6xl mx-auto">
        <div className="flex items-center justify-between">
          <div>
            <p className="text-sm text-white/50">Dashboard</p>

            <h1 className="text-5xl font-bold mt-2">Welcome back 😄</h1>
          </div>

          <button
            onClick={() => {
              localStorage.removeItem("token");

              router.push("/login");
            }}
            className="rounded-2xl border border-white/10 px-5 py-3 hover:bg-white/5 transition"
          >
            Logout
          </button>
        </div>

        <div className="mt-12 grid gap-6 md:grid-cols-3">
          <div className="rounded-3xl border border-white/10 bg-white/5 p-6">
            <p className="text-sm text-white/50">Active topics</p>

            <h2 className="mt-3 text-4xl font-bold">0</h2>
          </div>

          <div className="rounded-3xl border border-white/10 bg-white/5 p-6">
            <p className="text-sm text-white/50">Articles this week</p>

            <h2 className="mt-3 text-4xl font-bold">0</h2>
          </div>

          <div className="rounded-3xl border border-white/10 bg-white/5 p-6">
            <p className="text-sm text-white/50">Newsletters sent</p>

            <h2 className="mt-3 text-4xl font-bold">0</h2>
          </div>
        </div>
      </div>
    </main>
  );
}
