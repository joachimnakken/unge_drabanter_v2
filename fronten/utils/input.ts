type InputStatus = "error" | "default" | "valid";
type DirtyStatus = boolean;
type ErrorStatus = boolean;

export function getInputStatus(
  dirty: DirtyStatus,
  error?: ErrorStatus
): InputStatus {
  if (!dirty) {
    return "default";
  } else if (error) {
    return "error";
  } else {
    return "valid";
  }
}
