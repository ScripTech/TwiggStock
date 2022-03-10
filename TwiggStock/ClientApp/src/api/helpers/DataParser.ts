import { default as camelcase } from "camelcase-keys";

/**
 * Parses Data to Json Camelcase
 *
 * @param {Object}
 *
 * @return {T - JsonObject}
 */
export class DataParser {
  public static parseToCamelCase = <T>(data: any): T => {
    const result: T = JSON.parse(
      JSON.stringify(camelcase(data, { deep: true }))
    );
    return result;
  };
}
