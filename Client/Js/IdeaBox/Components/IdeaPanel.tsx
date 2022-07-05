import * as React from "react";
import { IAppModule } from "../Models/IAppModule";
import { Idea, IIdea } from "../Models/IIdea";

interface IIdeaPanelProps {
  module: IAppModule;
  idea: IIdea;
  onDelete: (idea: IIdea) => void;
  onEdit: (idea: IIdea) => void;
  onVote: (idea: IIdea, vote: number) => void;
}

const IdeaPanel: React.FC<IIdeaPanelProps> = (props) => {
  let f = new Intl.DateTimeFormat(props.module.locale);
  return (
    <div className="col-sm-3">
      <div className="panel panel-info">
        <div className="panel-heading">
          <h3 className="panel-title">{props.idea.Title}</h3>
        </div>
        <div className="panel-body">
          <div className="lead">{props.idea.Description}</div>
          <p className="small">
            {f.format(new Date(props.idea.CreatedOnDate))} - {props.idea.CreatedByUserDisplayName}
          </p>
          <div>
            {props.module.security.CanVote && (
              <>
                <a
                  href="#"
                  onClick={(e) => {
                    e.preventDefault();
                    props.onVote(props.idea, 1);
                  }}
                >
                  <span className="glyphicon glyphicon-thumbs-up"></span>
                </a>
                <a
                  href="#"
                  onClick={(e) => {
                    e.preventDefault();
                    props.onVote(props.idea, -1);
                  }}
                >
                  <span className="glyphicon glyphicon-thumbs-down"></span>
                </a>
              </>
            )}
            <span>{props.idea.TotalKarma}</span>
          </div>
        </div>
        <div className="panel-footer">
          <button
            onClick={(e) => {
              e.preventDefault();
              props.onEdit(props.idea);
            }}
            className="btn btn-sm btn-info"
          >
            {props.module.resources.EditIdea}
          </button>
          <button
            onClick={(e) => {
              e.preventDefault();
              props.onDelete(props.idea);
            }}
            className="btn btn-sm btn-danger"
          >
            {props.module.resources.Delete}
          </button>
        </div>
      </div>
    </div>
  );
};

export default IdeaPanel;
