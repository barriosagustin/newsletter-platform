"use client";

import { useEffect, useState } from "react";

import { getNewsletterPreview } from "@/services/newsletter-service";

type Article = {
  id: number;
  title: string;
  source: string;
  url: string;
  publishedAt: string;
};

export default function NewsletterPage() {
  const [articles, setArticles] = useState<Article[]>([]);

  useEffect(() => {
    async function loadArticles() {
      try {
        const data = await getNewsletterPreview();

        setArticles(data);
      } catch (error) {
        console.error(error);
      }
    }

    loadArticles();
  }, []);

  return (
    <main className="min-h-screen bg-black text-white p-8">
      <div className="max-w-5xl mx-auto">
        <div>
          <p className="text-sm text-white/50">Newsletter Preview</p>

          <h1 className="text-5xl font-bold mt-2">Your weekly digest</h1>
        </div>

        <div className="mt-12 grid gap-6">
          {articles.map((article) => (
            <a
              key={article.id}
              href={article.url}
              target="_blank"
              className="rounded-3xl border border-white/10 bg-white/5 p-8 hover:bg-white/10 transition"
            >
              <div className="flex items-center justify-between">
                <p className="text-sm text-white/40">{article.source}</p>

                <p className="text-sm text-white/40">
                  {new Date(article.publishedAt).toLocaleDateString()}
                </p>
              </div>

              <h2 className="mt-4 text-2xl font-semibold">{article.title}</h2>
            </a>
          ))}
        </div>
      </div>
    </main>
  );
}
