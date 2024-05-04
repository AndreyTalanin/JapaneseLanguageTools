import { Menu } from "antd";
import { useCallback, useMemo } from "react";
import { useLocation, useNavigate } from "react-router";

import type ApplicationPageDescriptor from "@/entities/application/ApplicationPageDescriptor";
import type ApplicationMenuItemDescriptor from "@/entities/application/ApplicationMenuItemDescriptor";

interface ApplicationMenuItem {
  key: string;
  label: string;
  children?: ApplicationMenuItem[];
}

export interface ApplicationMenuProps {
  applicationPageDescriptors: ApplicationPageDescriptor[];
  applicationMenuItemDescriptors: ApplicationMenuItemDescriptor[];
}

const ApplicationMenu = ({ applicationPageDescriptors, applicationMenuItemDescriptors }: ApplicationMenuProps) => {
  const location = useLocation();
  const navigate = useNavigate();

  const path = useMemo(() => location.pathname, [location]);

  const applicationMenuItems = useMemo(() => {
    const createApplicationMenuItem = ({ key, type, label, items }: ApplicationMenuItemDescriptor) => {
      let applicationMenuItem: ApplicationMenuItem;
      switch (type) {
        case "item":
          applicationMenuItem = { key: key, label: label };
          break;
        case "menu":
          applicationMenuItem = {
            key: key,
            label: label,
            children: items?.map((childApplicationMenuItemDescriptor) => createApplicationMenuItem(childApplicationMenuItemDescriptor)) ?? [],
          };
          break;
      }

      return applicationMenuItem;
    };

    return applicationMenuItemDescriptors.map((applicationMenuItemDescriptor) => createApplicationMenuItem(applicationMenuItemDescriptor));
  }, [applicationMenuItemDescriptors]);

  const selectedApplicationMenuItemKeys = useMemo(() => {
    let selectedApplicationMenuItemKey: string | undefined = undefined;

    const checkApplicationMenuItem = ({ key, children }: ApplicationMenuItem) => {
      const applicationPageDescriptor = applicationPageDescriptors.find((applicationPageDescriptor) => applicationPageDescriptor.key === key);
      if (applicationPageDescriptor) {
        const pathTerminator = "/";
        if ((path + pathTerminator).startsWith(applicationPageDescriptor.path + pathTerminator)) {
          selectedApplicationMenuItemKey = applicationPageDescriptor.key;
        }
        if (path === applicationPageDescriptor.path) {
          return true;
        }
      }

      if (children) {
        for (const child of children) {
          if (checkApplicationMenuItem(child)) {
            return true;
          }
        }
      }

      return false;
    };

    for (const applicationMenuItem of applicationMenuItems) {
      if (checkApplicationMenuItem(applicationMenuItem)) {
        break;
      }
    }

    // The selectedKey variable can be set multiple times from the checkApplicationMenuItem fuction.
    // eslint-disable-next-line @typescript-eslint/no-unnecessary-condition
    return selectedApplicationMenuItemKey ? [selectedApplicationMenuItemKey] : [];
  }, [applicationPageDescriptors, path, applicationMenuItems]);

  const onSelect = useCallback(
    (key: string) => {
      const applicationPageDescriptor = applicationPageDescriptors.find((applicationPageDescriptor) => applicationPageDescriptor.key === key);
      if (applicationPageDescriptor?.path) {
        navigate(applicationPageDescriptor.path);
      }
    },
    [applicationPageDescriptors, navigate]
  );

  // prettier-ignore
  return (
    <Menu
      mode="horizontal"
      theme="dark"
      items={applicationMenuItems}
      selectedKeys={selectedApplicationMenuItemKeys}
      onSelect={({ key }) => onSelect(key)}
    />
  );
};

export default ApplicationMenu;
