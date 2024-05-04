export default interface ApplicationPageDescriptor {
  key: string;
  path: string;
  name: string;
  disabled?: boolean;
  component?: React.ReactNode;
}
