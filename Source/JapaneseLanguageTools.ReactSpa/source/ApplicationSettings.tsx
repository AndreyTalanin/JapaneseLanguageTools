import { HomeOutlined } from "@ant-design/icons";

import { isProductionMode } from "@/ApplicationEnvironment";
import type ApplicationBreadcrumbItemDescriptor from "@/entities/application/ApplicationBreadcrumbItemDescriptor";
import type ApplicationMenuItemDescriptor from "@/entities/application/ApplicationMenuItemDescriptor";
import type ApplicationPageDescriptor from "@/entities/application/ApplicationPageDescriptor";
import HomePage from "@/pages/application/HomePage";
import InvalidRoutePage from "@/pages/application/InvalidRoutePage";
import SwaggerRedirectPage from "./pages/application/SwaggerRedirectPage";

// prettier-ignore
const redirectPageDescriptors: ApplicationPageDescriptor[] = [
  { key: "swagger-redirect-page", path: "/swagger", name: "Swagger API Explorer", disabled: isProductionMode(), component: <SwaggerRedirectPage /> },
];

// prettier-ignore
const errorPageDescriptors: ApplicationPageDescriptor[] = [
  { key: "invalid-route-page", path: "*", name: "Invalid Route", component: <InvalidRoutePage /> },
];

// prettier-ignore
export const applicationPageDescriptors: ApplicationPageDescriptor[] = [
  { key: "home-page", path: "/home", name: "Home", component: <HomePage /> },
  // Placeholder pages not existing in the application and routed via redirects instead.
  ...redirectPageDescriptors,
  // Error pages not displayed during normal operation.
  ...errorPageDescriptors,
];

// prettier-ignore
export const applicationMenuItemDescriptors: ApplicationMenuItemDescriptor[] = [
  { key: "home-page", label: "Home", type: "item" },
  { key: "swagger-redirect-page", label: "Swagger API Explorer", disabled: isProductionMode(), type: "item" },
];

// prettier-ignore
export const applicationBreadcrumbItemDescriptors: ApplicationBreadcrumbItemDescriptor[] = [
  { key: "home-page", useLink: true, icon: <HomeOutlined /> },
];
