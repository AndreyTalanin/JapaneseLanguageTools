import { expect, test } from "vitest";

import { render, screen } from "@testing-library/react";

import Application from "@/Application";

test("Renders 'Japanese Language Tools' header title", async () => {
  render(<Application />);
  const elements = await screen.findAllByText("Japanese Language Tools");
  const titleElement = elements
    .filter((element) => element.tagName == "strong".toUpperCase())
    .filter((element) => element.parentElement)
    .find((element) =>
      Array.from(element.parentElement?.classList.entries() ?? [])
        .map(([, value]) => value)
        .find((className) => className.startsWith("_applicationTitleText"))
    );
  expect(titleElement).toBeDefined();
});

test("Renders 'Copyright © 2024 Andrey Talanin' footer paragraph", async () => {
  render(<Application />);
  const elements = await screen.findAllByText("Copyright © 2024 Andrey Talanin. See the Home page for project details.");
  const titleElement = elements.find((element) =>
    Array.from(element.classList.entries())
      .map(([, value]) => value)
      .find((className) => className.startsWith("_applicationFooter"))
  );
  expect(titleElement).toBeDefined();
});
