"use client";

import { useEffect, useState } from "react";
import { useRouter } from "next/navigation";
import { isAuthenticated } from "@/lib/auth";
import { getTopics } from "@/services/topic-service";
import { Topic } from "@/types/topic";
import { selectTopic } from "@/services/user-topic-service";

export default function DashboardPage() {
  const router = useRouter();
  const [topics, setTopics] = useState<Topic[]>([]);
  const [loading, setLoading] = useState(true);

  // Verificar auth
  useEffect(() => {
    if (!isAuthenticated()) {
      router.push("/login");
    }
  }, [router]);

  // Cargar datos
  useEffect(() => {
    let cancelled = false;

    async function loadTopics() {
      try {
        const data = await getTopics();
        if (!cancelled) {
          setTopics(data);
        }
      } catch (error) {
        console.error("Error loading topics:", error);
      } finally {
        if (!cancelled) {
          setLoading(false);
        }
      }
    }

    loadTopics();

    return () => {
      cancelled = true;
    };
  }, []);

  const handleLogout = () => {
    localStorage.removeItem("token");
    router.push("/login");
  };

  async function handleSelectTopic(topicId: number) {
    try {
      await selectTopic(topicId);

      alert("Topic selected 😄");
    } catch (error) {
      console.error(error);

      alert("Topic already selected");
    }
  }

  return (
    <main className="min-h-screen bg-black text-white p-8">
      <div className="max-w-6xl mx-auto">
        <div className="flex items-center justify-between">
          <div>
            <p className="text-sm text-white/50">Dashboard</p>
            <h1 className="text-5xl font-bold mt-2">Your interests</h1>
          </div>
          <button
            onClick={handleLogout}
            className="rounded-2xl border border-white/10 px-5 py-3 hover:bg-white/5 transition"
          >
            Logout
          </button>
        </div>

        <div className="mt-12">
          <h2 className="text-2xl font-semibold mb-6">
            Choose your newsletter topics
          </h2>

          {loading ? (
            <p className="text-white/50">Loading...</p>
          ) : (
            <div className="grid gap-4 md:grid-cols-3">
              {topics.map((topic) => (
                <div
                  key={topic.id}
                  onClick={() => handleSelectTopic(topic.id)}
                  className="rounded-3xl border border-white/10 bg-white/5 p-6 hover:bg-white/10 transition cursor-pointer"
                >
                  <h3 className="text-xl font-semibold">{topic.name}</h3>
                  <p className="mt-2 text-sm text-white/50">
                    Personalized weekly updates
                  </p>
                </div>
              ))}
            </div>
          )}
        </div>
      </div>
    </main>
  );
}
