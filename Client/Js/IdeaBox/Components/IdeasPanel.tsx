import * as React from "react";
import { IAppModule } from "../Models/IAppModule";
import { Idea, IIdea } from "../Models/IIdea";
import EditIdea from "./EditIdea";
import IdeaPanel from "./IdeaPanel";

interface IIdeasPanelProps {
  module: IAppModule;
}

const IdeasPanel: React.FC<IIdeasPanelProps> = (props) => {
  const [ideas, setIdeas] = React.useState<IIdea[]>([]);
  const [ideaUnderEdit, setIdeaUnderEdit] = React.useState<IIdea | null>(null);
  const [showEditIdea, setShowEditIdea] = React.useState(false);
  React.useEffect(() => {
    props.module.service.getIdeas((data: IIdea[]) => {
      setIdeas(data);
    });
  }, []);
  return (
    <div>
      <div className="row">
        {ideas.map((idea) => (
          <IdeaPanel
            module={props.module}
            idea={idea}
            key={idea.IdeaId}
            onDelete={(idea) => {
              props.module.service.deleteIdea(idea.IdeaId, () => {
                setIdeas(ideas.filter((i) => i.IdeaId !== idea.IdeaId));
              });
            }}
            onEdit={(idea) => {
              setIdeaUnderEdit(idea);
              setShowEditIdea(true);
            }}
            onVote={(idea, vote) => {
              props.module.service.vote(idea.IdeaId, vote, (idea: IIdea) => {
                setIdeas(ideas.map((i) => (i.IdeaId === idea.IdeaId ? idea : i)));
              });
            }}
          />
        ))}
      </div>
      <EditIdea
        module={props.module}
        idea={ideaUnderEdit}
        show={showEditIdea}
        onClose={() => setShowEditIdea(false)}
        onUpdate={(idea) => {
          setShowEditIdea(false);
          props.module.service.updateIdea(idea, () => {
            props.module.service.getIdeas((data: IIdea[]) => {
              setIdeas(data);
            });
          });
          setIdeaUnderEdit(null);
        }}
      />
      {props.module.security.CanSubmit && (
        <div>
          <button
            onClick={(e) => {
              e.preventDefault();
              setIdeaUnderEdit(new Idea());
              setShowEditIdea(true);
            }}
            className="btn btn-primary"
          >
            {props.module.resources.AddIdea}
          </button>
        </div>
      )}
    </div>
  );
};

export default IdeasPanel;
