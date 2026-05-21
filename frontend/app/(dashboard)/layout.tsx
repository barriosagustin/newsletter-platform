"use client";

import Link from "next/link";

import { usePathname } from "next/navigation";

import { ReactNode } from "react";

export default function DashboardLayout({ children }: { children: ReactNode }) {
  const pathname = usePathname();

  return (
    <div className="min-h-screen bg-black text-white flex">
      <aside className="w-72 border-r border-white/10 bg-white/[0.03] backdrop-blur-xl p-6 hidden md:flex flex-col">
        <div>
          <h1 className="text-2xl font-bold">Newsletter Platform</h1>

          <p className="text-sm text-white/40 mt-2">
            Personalized news intelligence
          </p>
        </div>

        <nav className="mt-12 flex flex-col gap-2">
          <Link
            href="/dashboard"
            className={`rounded-2xl px-4 py-3 transition ${
              pathname === "/dashboard"
                ? "bg-white text-black"
                : "hover:bg-white/10"
            }`}
          >
            Dashboard
          </Link>

          <Link
            href="/settings"
            className={`rounded-2xl px-4 py-3 transition ${
              pathname === "/settings"
                ? "bg-white text-black"
                : "hover:bg-white/10"
            }`}
          >
            Settings
          </Link>

          <Link
            href="/newsletter"
            className={`rounded-2xl px-4 py-3 transition ${
              pathname === "/newsletter"
                ? "bg-white text-black"
                : "hover:bg-white/10"
            }`}
          >
            Newsletter
          </Link>
        </nav>

        <div className="mt-auto">
          <button
            onClick={() => {
              localStorage.removeItem("token");

              window.location.href = "/login";
            }}
            className="w-full rounded-2xl border border-white/10 px-4 py-3 hover:bg-white/5 transition"
          >
            Logout
          </button>
        </div>
      </aside>

      <main className="flex-1">{children}</main>
    </div>
  );
}
