import { parseAsBoolean, useQueryState } from "nuqs";

export const useCreatePlantsModal = () => {
  const [isOpen, setIsOpen] = useQueryState(
    "create-plant",
    parseAsBoolean.withDefault(false).withOptions({ clearOnDefault: true })
  );

  const open = () => setIsOpen(true)
  const close = () => setIsOpen(false)

  return {
    isOpen,
    open,
    close,
    setIsOpen
  }
};
