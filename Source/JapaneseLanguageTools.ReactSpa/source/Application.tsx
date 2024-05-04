import { BrowserRouter } from "react-router-dom";

import ApplicationLayout from "@/ApplicationLayout";
import * as ApplicationSettings from "@/ApplicationSettings";

const applicationPageDescriptors = ApplicationSettings.applicationPageDescriptors.filter((descriptor) => !descriptor.disabled);
const applicationMenuItemDescriptors = ApplicationSettings.applicationMenuItemDescriptors.filter((descriptor) => !descriptor.disabled);
const applicationBreadcrumbItemDescriptors = ApplicationSettings.applicationBreadcrumbItemDescriptors;

const Application = () => {
  // prettier-ignore
  return (
    <BrowserRouter>
      <ApplicationLayout
        applicationPageDescriptors={applicationPageDescriptors}
        applicationMenuItemDescriptors={applicationMenuItemDescriptors}
        applicationBreadcrumbItemDescriptors={applicationBreadcrumbItemDescriptors}
      />
    </BrowserRouter>
  );
};

export default Application;
