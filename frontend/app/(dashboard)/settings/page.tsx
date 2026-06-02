"use client";

import { useEffect, useState } from "react";

import { useRouter } from "next/navigation";

import { isAuthenticated } from "@/lib/auth";

import {
  getCurrentUser,
  updateNewsletterSettings,
} from "@/services/user-service";

export default function SettingsPage() {
  const router = useRouter();

  const [loading, setLoading] = useState(true);

  const [saving, setSaving] = useState(false);

  const [newsletterEnabled, setNewsletterEnabled] = useState(true);

  const [newsletterFrequency, setNewsletterFrequency] = useState("Weekly");

  useEffect(() => {
    if (!isAuthenticated()) {
      router.push("/login");
      return;
    }

    async function loadUser() {
      try {
        const user = await getCurrentUser();
        setNewsletterEnabled(user.newsletterEnabled);
        setNewsletterFrequency(user.newsletterFrequency);
      } catch (error) {
        console.error(error);
      } finally {
        setLoading(false);
      }
    }

    loadUser();
  }, [router]);

  async function handleSave() {
    try {
      setSaving(true);

      await updateNewsletterSettings({
        newsletterEnabled,
        newsletterFrequency,
      });

      alert("Settings saved 😄");
    } catch (error) {
      console.error(error);

      alert("Failed to save");
    } finally {
      setSaving(false);
    }
  }

  if (loading) {
    return (
      <main className="min-h-screen bg-black text-white flex items-center justify-center">
        Loading...
      </main>
    );
  }

  return (
    <main className="min-h-screen bg-black text-white p-8">
      <div className="max-w-3xl mx-auto">
        <div>
          <p className="text-sm text-white/50">Settings</p>

          <h1 className="text-5xl font-bold mt-2">Newsletter preferences</h1>
        </div>

        <div className="mt-12 rounded-3xl border border-white/10 bg-white/5 p-8">
          <div className="flex items-center justify-between">
            <div>
              <h2 className="text-xl font-semibold">Enable newsletter</h2>

              <p className="text-sm text-white/50 mt-2">
                Receive personalized news updates.
              </p>
            </div>

            <input
              type="checkbox"
              checked={newsletterEnabled}
              onChange={(e) => setNewsletterEnabled(e.target.checked)}
              className="h-6 w-6"
            />
          </div>

          <div className="mt-10">
            <label className="block text-sm text-white/50 mb-3">
              Frequency
            </label>

            <select
              value={newsletterFrequency}
              onChange={(e) => setNewsletterFrequency(e.target.value)}
              className="w-full rounded-2xl bg-black border border-white/10 px-4 py-3 outline-none"
            >
              <option value="Weekly">Weekly</option>

              <option value="Monthly">Monthly</option>
            </select>
          </div>

          <button
            onClick={handleSave}
            disabled={saving}
            className="mt-10 w-full rounded-2xl bg-white text-black py-3 font-medium hover:opacity-90 transition"
          >
            {saving ? "Saving..." : "Save settings"}
          </button>
        </div>
      </div>
    </main>
  );
}
