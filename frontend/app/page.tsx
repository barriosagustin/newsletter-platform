import Link from "next/link";

type Feature = {
  title: string;
  description: string;
};

type Step = {
  label: string;
  title: string;
  description: string;
};

const problems = [
  "Information overload turns staying informed into another full-time job.",
  "Endless scrolling buries useful updates under noise, hot takes, and ads.",
  "Too many notifications fracture attention before the day even starts.",
  "Important topics are hard to follow consistently across scattered sources.",
];

const features: Feature[] = [
  {
    title: "Personalized Topics",
    description: "Choose the subjects that matter to your work, portfolio, and curiosity.",
  },
  {
    title: "Weekly Digests",
    description: "Receive focused summaries on a predictable cadence without refreshing feeds.",
  },
  {
    title: "Automated Delivery",
    description: "Let the platform collect, prepare, and send your newsletter automatically.",
  },
  {
    title: "Curated Content",
    description: "Filter out low-signal noise and keep the updates worth reading.",
  },
  {
    title: "Simple Dashboard",
    description: "Manage topics, preferences, and delivery settings from one quiet workspace.",
  },
  {
    title: "Privacy Focused",
    description: "Designed around deliberate reading, not tracking, engagement loops, or feeds.",
  },
];

const steps: Step[] = [
  {
    label: "Step 1",
    title: "Create Account",
    description: "Start with a clean profile built around your information needs.",
  },
  {
    label: "Step 2",
    title: "Select Topics",
    description: "Pick areas like technology, markets, startups, AI, or your own niche interests.",
  },
  {
    label: "Step 3",
    title: "Receive Newsletter",
    description: "Get curated updates delivered automatically, without returning to the scroll.",
  },
];

function SectionHeader({
  eyebrow,
  title,
  description,
}: {
  eyebrow: string;
  title: string;
  description: string;
}) {
  return (
    <div className="mx-auto max-w-3xl text-center">
      <p className="text-sm font-medium uppercase tracking-[0.22em] text-emerald-300/80">{eyebrow}</p>
      <h2 className="mt-4 text-3xl font-semibold tracking-tight text-white sm:text-4xl">{title}</h2>
      <p className="mt-4 text-base leading-7 text-zinc-400 sm:text-lg">{description}</p>
    </div>
  );
}

function FeatureCard({ title, description }: Feature) {
  return (
    <article className="group rounded-2xl border border-white/10 bg-white/[0.04] p-6 shadow-2xl shadow-black/20 backdrop-blur transition duration-300 hover:-translate-y-1 hover:border-emerald-300/30 hover:bg-white/[0.07]">
      <div className="mb-5 flex h-11 w-11 items-center justify-center rounded-xl border border-white/10 bg-black/40 text-sm font-semibold text-emerald-200 transition group-hover:border-emerald-300/30">
        {title
          .split(" ")
          .map((word) => word[0])
          .join("")}
      </div>
      <h3 className="text-lg font-semibold text-white">{title}</h3>
      <p className="mt-3 text-sm leading-6 text-zinc-400">{description}</p>
    </article>
  );
}

function HeroBackdrop() {
  const topics = ["AI", "Markets", "Startups", "Security", "Climate", "Product"];
  const updates = [
    "3 signal-rich AI policy updates",
    "Market brief with volatility context",
    "Developer tooling releases worth knowing",
    "Founder notes from trusted sources",
    "Security advisories summarized clearly",
  ];

  return (
    <div aria-hidden="true" className="absolute inset-0 overflow-hidden">
      <div className="absolute inset-0 bg-black" />
      <div className="absolute left-1/2 top-10 grid w-[980px] -translate-x-1/2 grid-cols-6 gap-3 opacity-30 sm:top-8 sm:opacity-45 lg:w-[1180px]">
        {topics.map((topic) => (
          <div
            key={topic}
            className="h-16 rounded-2xl border border-white/10 bg-white/[0.05] px-4 py-3 shadow-2xl shadow-black/30 backdrop-blur"
          >
            <div className="h-2 w-8 rounded-full bg-emerald-300/70" />
            <div className="mt-3 text-xs font-medium text-white/70">{topic}</div>
          </div>
        ))}
      </div>
      <div className="absolute left-1/2 top-44 hidden w-[1050px] -translate-x-1/2 grid-cols-5 gap-4 opacity-30 md:grid">
        {updates.map((update) => (
          <div key={update} className="rounded-3xl border border-white/10 bg-white/[0.045] p-4 backdrop-blur-xl">
            <div className="mb-5 flex items-center gap-2">
              <span className="h-2 w-2 rounded-full bg-emerald-300" />
              <span className="h-2 w-16 rounded-full bg-white/20" />
            </div>
            <p className="text-sm leading-5 text-white/70">{update}</p>
            <div className="mt-5 space-y-2">
              <div className="h-2 rounded-full bg-white/15" />
              <div className="h-2 w-3/4 rounded-full bg-white/10" />
            </div>
          </div>
        ))}
      </div>
      <div className="absolute inset-x-0 bottom-0 h-56 bg-black" />
    </div>
  );
}

export default function HomePage() {
  return (
    <main className="min-h-screen bg-black text-white">
      <section className="relative flex min-h-screen overflow-hidden">
        <HeroBackdrop />

        <div className="relative z-10 mx-auto flex w-full max-w-7xl flex-col px-6 pb-16 pt-6 sm:px-8 lg:px-10">
          <nav className="flex items-center justify-between">
            <Link href="/" className="text-sm font-semibold tracking-tight text-white sm:text-base">
              Newsletter Platform
            </Link>
            <div className="flex items-center gap-3">
              <Link
                href="/login"
                className="rounded-full border border-white/10 px-4 py-2 text-sm font-medium text-zinc-300 transition hover:border-white/25 hover:text-white"
              >
                Sign In
              </Link>
              <Link
                href="/register"
                className="rounded-full bg-white px-4 py-2 text-sm font-semibold text-black transition hover:bg-emerald-200"
              >
                Get Started
              </Link>
            </div>
          </nav>

          <div className="flex flex-1 items-center justify-center py-24 text-center sm:py-28">
            <div className="max-w-5xl">
              <p className="mx-auto mb-6 w-fit rounded-full border border-emerald-300/20 bg-emerald-300/10 px-4 py-2 text-sm font-medium text-emerald-100 backdrop-blur">
                Curated news for people who value their attention
              </p>
              <h1 className="text-5xl font-semibold tracking-tight text-white sm:text-6xl lg:text-7xl">
                Stay informed without losing your day to the internet.
              </h1>
              <p className="mx-auto mt-7 max-w-2xl text-base leading-8 text-zinc-300 sm:text-lg">
                Newsletter Platform helps professionals, developers, investors, and entrepreneurs receive only the most important news about the topics they care about.
              </p>
              <div className="mt-10 flex flex-col items-center justify-center gap-4 sm:flex-row">
                <Link
                  href="/register"
                  className="w-full rounded-full bg-white px-7 py-3.5 text-sm font-semibold text-black shadow-2xl shadow-white/10 transition hover:-translate-y-0.5 hover:bg-emerald-200 sm:w-auto"
                >
                  Get Started
                </Link>
                <Link
                  href="/login"
                  className="w-full rounded-full border border-white/15 bg-white/[0.03] px-7 py-3.5 text-sm font-semibold text-white backdrop-blur transition hover:-translate-y-0.5 hover:border-white/30 hover:bg-white/[0.06] sm:w-auto"
                >
                  Sign In
                </Link>
              </div>
            </div>
          </div>
        </div>
      </section>

      <section className="border-y border-white/10 bg-zinc-950 px-6 py-24 sm:px-8 lg:px-10">
        <div className="mx-auto max-w-7xl">
          <SectionHeader
            eyebrow="The Problem"
            title="The modern news habit is expensive."
            description="Staying current should not require checking five apps, opening twenty tabs, and donating your best attention to infinite feeds."
          />

          <div className="mt-14 grid gap-4 md:grid-cols-2">
            {problems.map((problem) => (
              <div key={problem} className="rounded-2xl border border-white/10 bg-black/40 p-6 transition hover:border-white/20">
                <p className="text-base leading-7 text-zinc-300">{problem}</p>
              </div>
            ))}
          </div>
        </div>
      </section>

      <section className="bg-black px-6 py-24 sm:px-8 lg:px-10">
        <div className="mx-auto grid max-w-7xl items-center gap-12 lg:grid-cols-[0.95fr_1.05fr]">
          <div>
            <p className="text-sm font-medium uppercase tracking-[0.22em] text-emerald-300/80">The Solution</p>
            <h2 className="mt-4 text-3xl font-semibold tracking-tight text-white sm:text-4xl">
              Replace the scroll with a deliberate reading ritual.
            </h2>
            <p className="mt-5 text-base leading-8 text-zinc-400 sm:text-lg">
              Choose the topics you care about, let Newsletter Platform curate the important updates, and receive a clean digest automatically. No feeds to chase. No notification pileup. Just the context you need to keep moving.
            </p>
          </div>

          <div className="rounded-3xl border border-white/10 bg-white/[0.04] p-5 shadow-2xl shadow-black/40 backdrop-blur">
            <div className="rounded-2xl border border-white/10 bg-black/70 p-5">
              <div className="mb-6 flex items-center justify-between">
                <div>
                  <p className="text-sm text-zinc-500">Next digest</p>
                  <h3 className="mt-1 text-xl font-semibold text-white">Monday Brief</h3>
                </div>
                <span className="rounded-full border border-emerald-300/20 bg-emerald-300/10 px-3 py-1 text-xs font-medium text-emerald-100">
                  Ready
                </span>
              </div>
              <div className="space-y-3">
                {["AI infrastructure", "Venture markets", "Developer tools"].map((topic) => (
                  <div key={topic} className="flex items-center justify-between rounded-2xl border border-white/10 bg-white/[0.04] px-4 py-3">
                    <span className="text-sm text-zinc-200">{topic}</span>
                    <span className="text-xs text-zinc-500">Curated</span>
                  </div>
                ))}
              </div>
            </div>
          </div>
        </div>
      </section>

      <section className="bg-zinc-950 px-6 py-24 sm:px-8 lg:px-10">
        <div className="mx-auto max-w-7xl">
          <SectionHeader
            eyebrow="Features"
            title="Everything you need. Nothing designed to trap you."
            description="A focused product for people who want awareness without the ambient pressure of always being online."
          />

          <div className="mt-14 grid gap-5 sm:grid-cols-2 lg:grid-cols-3">
            {features.map((feature) => (
              <FeatureCard key={feature.title} {...feature} />
            ))}
          </div>
        </div>
      </section>

      <section className="bg-black px-6 py-24 sm:px-8 lg:px-10">
        <div className="mx-auto max-w-7xl">
          <SectionHeader
            eyebrow="How It Works"
            title="Three steps from noisy feeds to useful context."
            description="The setup is intentionally simple, so the product stays focused on saving time."
          />

          <div className="mt-14 grid gap-5 lg:grid-cols-3">
            {steps.map((step) => (
              <article key={step.label} className="rounded-3xl border border-white/10 bg-white/[0.04] p-7 transition hover:-translate-y-1 hover:border-emerald-300/30">
                <p className="text-sm font-medium text-emerald-300">{step.label}</p>
                <h3 className="mt-5 text-xl font-semibold text-white">{step.title}</h3>
                <p className="mt-3 text-sm leading-6 text-zinc-400">{step.description}</p>
              </article>
            ))}
          </div>
        </div>
      </section>

      <section className="border-y border-white/10 bg-zinc-950 px-6 py-24 text-center sm:px-8 lg:px-10">
        <div className="mx-auto max-w-4xl">
          <h2 className="text-4xl font-semibold tracking-tight text-white sm:text-5xl">
            Start receiving only what matters.
          </h2>
          <p className="mx-auto mt-5 max-w-2xl text-base leading-7 text-zinc-400 sm:text-lg">
            Build a calmer news habit with curated newsletters around the topics that actually deserve your attention.
          </p>
          <Link
            href="/register"
            className="mt-10 inline-flex rounded-full bg-white px-8 py-4 text-sm font-semibold text-black shadow-2xl shadow-white/10 transition hover:-translate-y-0.5 hover:bg-emerald-200"
          >
            Register
          </Link>
        </div>
      </section>

      <footer className="bg-black px-6 py-10 sm:px-8 lg:px-10">
        <div className="mx-auto flex max-w-7xl flex-col gap-4 text-sm text-zinc-500 sm:flex-row sm:items-center sm:justify-between">
          <p className="font-medium text-zinc-300">Newsletter Platform</p>
          <p>Stay informed without doomscrolling.</p>
        </div>
      </footer>
    </main>
  );
}
