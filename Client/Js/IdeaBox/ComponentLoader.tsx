import * as React from "react";
import * as ReactDOM from "react-dom";

import { AppManager } from "./AppManager";
import IdeasPanel from "./Components/IdeasPanel";

export class ComponentLoader {
  public static load(): void {
    document.querySelectorAll(".IdeaBox").forEach((el) => {
      var moduleId = el.dataInt("moduleid");
      ReactDOM.render(<IdeasPanel module={AppManager.Modules.Item(moduleId.toString())} />, el);
    });
  }
}
