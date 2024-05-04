import { Breadcrumb, BreadcrumbProps, Layout, Space, Typography } from "antd";
import { useMemo } from "react";
import { Link, Navigate, Route, Routes, matchPath, useLocation } from "react-router-dom";

import ApplicationMenu from "@/ApplicationMenu";
import type ApplicationBreadcrumbItemDescriptor from "@/entities/application/ApplicationBreadcrumbItemDescriptor";
import type ApplicationMenuItemDescriptor from "@/entities/application/ApplicationMenuItemDescriptor";
import type ApplicationPageDescriptor from "@/entities/application/ApplicationPageDescriptor";

import styles from "./ApplicationLayout.module.css";

export interface ApplicationLayoutProps {
  applicationPageDescriptors: ApplicationPageDescriptor[];
  applicationMenuItemDescriptors: ApplicationMenuItemDescriptor[];
  applicationBreadcrumbItemDescriptors: ApplicationBreadcrumbItemDescriptor[];
}

const ApplicationLayout = ({ applicationPageDescriptors, applicationMenuItemDescriptors, applicationBreadcrumbItemDescriptors }: ApplicationLayoutProps) => {
  const location = useLocation();

  const path = useMemo(() => location.pathname, [location]);

  const breadcrumbItems = useMemo(() => {
    let matchedLeafRoute = false;
    let matchedApplicationPageDescriptors = applicationPageDescriptors.filter((route) => {
      const trimTrailingPathSeparator = (path: string): string => {
        return path.endsWith("/") ? path.substring(0, path.length - 1) : path;
      };

      if (route.path === "*") {
        return false;
      }

      if (matchPath(route.path, path)) {
        matchedLeafRoute ||= true;
        return true;
      } else if (matchPath(`${trimTrailingPathSeparator(route.path)}/*`, path)) {
        return true;
      }

      return false;
    });

    // The matchedLeafRoute variable can be set to true if any leaf application page's route was matched.
    // eslint-disable-next-line @typescript-eslint/no-unnecessary-condition
    if (!matchedLeafRoute) {
      matchedApplicationPageDescriptors = [...matchedApplicationPageDescriptors, ...applicationPageDescriptors.filter((route) => route.path === "*")];
    }

    const applicationBreadcrumbItemDescriptorsMap = new Map<string, ApplicationBreadcrumbItemDescriptor>();
    for (const applicationBreadcrumbItemDescriptor of applicationBreadcrumbItemDescriptors) {
      applicationBreadcrumbItemDescriptorsMap.set(applicationBreadcrumbItemDescriptor.key, applicationBreadcrumbItemDescriptor);
    }

    type BreadcrumbItems = BreadcrumbProps["items"];
    const breadcrumbItems: BreadcrumbItems = matchedApplicationPageDescriptors.map((matchedApplicationPageDescriptor, index) => {
      let title: React.ReactNode = matchedApplicationPageDescriptor.name;

      const applicationBreadcrumbItemDescriptor = applicationBreadcrumbItemDescriptorsMap.get(matchedApplicationPageDescriptor.key);

      if (applicationBreadcrumbItemDescriptor?.icon) {
        title = (
          <span>
            {applicationBreadcrumbItemDescriptor.icon} {title}
          </span>
        );
      }
      if (applicationBreadcrumbItemDescriptor?.useLink) {
        title = <Link to={matchedApplicationPageDescriptor.path}>{title}</Link>;
      }

      return {
        key: index,
        title: title,
      };
    });

    return breadcrumbItems;
  }, [applicationPageDescriptors, applicationBreadcrumbItemDescriptors, path]);

  const routes = useMemo(() => {
    const pageRoutes = applicationPageDescriptors
      .filter((applicationPageDescriptor) => applicationPageDescriptor.component)
      .map((applicationPageDescriptor) => {
        const { key, path, component } = applicationPageDescriptor;

        const element: JSX.Element = <>{component}</>;

        return <Route key={key} path={path} element={element} />;
      });

    const homeRedirectRoute = <Route key="root-redirect" path="/" element={<Navigate to="/home" replace />} />;

    return [homeRedirectRoute, ...pageRoutes];
  }, [applicationPageDescriptors]);

  return (
    <Layout className={styles.application}>
      <Layout.Header className={styles.applicationHeader}>
        <Space className={styles.applicationTitle} direction="horizontal">
          <Typography.Text strong className={styles.applicationTitleText}>
            Japanese Language Tools
          </Typography.Text>
        </Space>
        <ApplicationMenu applicationMenuItemDescriptors={applicationMenuItemDescriptors} applicationPageDescriptors={applicationPageDescriptors} />
      </Layout.Header>
      <Layout>
        <Layout className={styles.applicationPageWrapper}>
          <Breadcrumb className={styles.applicationBreadcrumb} items={breadcrumbItems} />
          <Layout.Content className={styles.applicationPageWrapperContent}>
            <Routes>{routes}</Routes>
          </Layout.Content>
          <Layout.Footer className={styles.applicationFooter}>Copyright © 2024 Andrey Talanin. See the Home page for project details.</Layout.Footer>
        </Layout>
      </Layout>
    </Layout>
  );
};

export default ApplicationLayout;
