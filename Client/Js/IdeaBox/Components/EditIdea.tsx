import * as React from "react";
import { linkState } from "../LinkState";
import { IAppModule } from "../Models/IAppModule";
import { Idea, IIdea } from "../Models/IIdea";

interface IEditIdeaProps {
  module: IAppModule;
  idea: IIdea | null;
  show: boolean;
  onClose: () => void;
  onUpdate: (idea: IIdea) => void;
}

const EditIdea: React.FC<IEditIdeaProps> = (props) => {
  const dialog = React.useRef(null);
  const [idea, setIdea] = React.useState<IIdea>(props.idea || new Idea());

  React.useEffect(() => {
    if (dialog.current) {
      ($(dialog.current) as any).on("hidden.bs.modal", () => {
        props.onClose();
      });
    }
  }, []);

  React.useEffect(() => {
    if (dialog.current) {
      ($(dialog.current) as any).modal(props.show ? "show" : "hide");
    }
  }, [props.show]);

  React.useEffect(() => {
    if (props.idea) {
      setIdea(props.idea);
    } else {
      setIdea(new Idea());
    }
  }, [props.idea]);

  return (
    <div className="modal fade" role="dialog" ref={dialog}>
      <div className="modal-dialog" role="document">
        <div className="modal-content">
          <div className="modal-header">
            <button type="button" className="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
            <h4 className="modal-title">{props.module.resources.EditIdea}</h4>
          </div>
          <div className="modal-body">
            <div className="form-group">
              <label>{props.module.resources.Title}</label>
              <input
                type="text"
                className="form-control"
                placeholder={props.module.resources.Title}
                onChange={(e) => setIdea({ ...idea, Title: e.target.value })}
                value={idea.Title}
              />
            </div>
            <div className="form-group">
              <label>{props.module.resources.Description}</label>
              <textarea
                className="form-control"
                placeholder={props.module.resources.Description}
                onChange={(e) => setIdea({ ...idea, Description: e.target.value })}
                value={idea.Description}
                rows={5}
              />
            </div>
          </div>
          <div className="modal-footer">
            <button type="button" className="btn btn-default" data-dismiss="modal">
              {props.module.resources.Cancel}
            </button>
            <button
              type="button"
              className="btn btn-primary"
              disabled={idea.Title === ""}
              onClick={(e) => {
                props.onUpdate(idea);
              }}
            >
              {props.module.resources.SaveChanges}
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default EditIdea;
