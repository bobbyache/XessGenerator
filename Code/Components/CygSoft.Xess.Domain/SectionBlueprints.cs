using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CygX1.XessGenerator.Domain
{
    public class SectionBlueprints
    {
        private Blueprint footerBlueprint = null;
        private Blueprint headerBlueprint = null;
        private Blueprint bodyBlueprint = null;

        public void SetText(BlueprintTypeEnum partType, string text)
        {
            switch (partType)
            {
                case BlueprintTypeEnum.Header:
                    break;

                case BlueprintTypeEnum.Body:
                    break;
                case BlueprintTypeEnum.Footer:
                    break;
            }
        }

        public string GetText(BlueprintTypeEnum partType)
        {
            switch (partType)
            {
                case BlueprintTypeEnum.Header:
                    break;

                case BlueprintTypeEnum.Body:
                    break;
                case BlueprintTypeEnum.Footer:
                    break;
            }
            return string.Empty;
        }

        public void SetTextTrimming(BlueprintTypeEnum partType, bool trim)
        {
            switch (partType)
            {
                case BlueprintTypeEnum.Header:
                    break;

                case BlueprintTypeEnum.Body:
                    break;
                case BlueprintTypeEnum.Footer:
                    break;
            }
        }

        public bool GetTextTrimming(BlueprintTypeEnum partType)
        {
            switch (partType)
            {
                case BlueprintTypeEnum.Header:
                    break;

                case BlueprintTypeEnum.Body:
                    break;
                case BlueprintTypeEnum.Footer:
                    break;
            }
            return false;
        }

        public void SetAppendNewLineBefore(BlueprintTypeEnum partType, bool newLineBefore)
        {
            switch (partType)
            {
                case BlueprintTypeEnum.Header:
                    break;

                case BlueprintTypeEnum.Body:
                    break;
                case BlueprintTypeEnum.Footer:
                    break;
            }
        }

        public bool GetAppendNewLineBefore(BlueprintTypeEnum partType)
        {
            switch (partType)
            {
                case BlueprintTypeEnum.Header:
                    break;

                case BlueprintTypeEnum.Body:
                    break;
                case BlueprintTypeEnum.Footer:
                    break;
            }
            return false;
        }

        public void SetAppendNewLineAfter(BlueprintTypeEnum partType, bool newLineAfter)
        {
            switch (partType)
            {
                case BlueprintTypeEnum.Header:
                    break;

                case BlueprintTypeEnum.Body:
                    break;
                case BlueprintTypeEnum.Footer:
                    break;
            }
        }

        public bool GetAppendNewLineAfter(BlueprintTypeEnum partType)
        {
            switch (partType)
            {
                case BlueprintTypeEnum.Header:
                    break;

                case BlueprintTypeEnum.Body:
                    break;
                case BlueprintTypeEnum.Footer:
                    break;
            }
            return false;
        }

        internal void Load(string id, string text, bool trimText, bool AppendNewLineBefore, bool AppendNewLineAfter, BlueprintTypeEnum partType)
        {
            switch (partType)
            {
                case BlueprintTypeEnum.Header:
                    this.headerBlueprint = new Blueprint(id);
                    this.headerBlueprint.Text = text;
                    this.headerBlueprint.TrimText = trimText;
                    this.headerBlueprint.AppendNewLineAfter = AppendNewLineAfter;
                    this.headerBlueprint.AppendNewLineBefore = AppendNewLineBefore;
                    break;

                case BlueprintTypeEnum.Body:
                    this.bodyBlueprint = new Blueprint(id);
                    this.bodyBlueprint.Text = text;
                    this.bodyBlueprint.TrimText = trimText;
                    this.bodyBlueprint.AppendNewLineAfter = AppendNewLineAfter;
                    this.bodyBlueprint.AppendNewLineBefore = AppendNewLineBefore;
                    break;
                case BlueprintTypeEnum.Footer:
                    this.footerBlueprint = new Blueprint(id);
                    this.footerBlueprint.Text = text;
                    this.footerBlueprint.TrimText = trimText;
                    this.footerBlueprint.AppendNewLineAfter = AppendNewLineAfter;
                    this.footerBlueprint.AppendNewLineBefore = AppendNewLineBefore;
                    break;
            }

        }

        public SectionBlueprints Clone()
        {
            SectionBlueprints cloneSectionBlueprints = new SectionBlueprints();

            cloneSectionBlueprints.Load(headerBlueprint.Id, headerBlueprint.Text, headerBlueprint.TrimText,
                headerBlueprint.AppendNewLineBefore, headerBlueprint.AppendNewLineAfter, BlueprintTypeEnum.Header);

            cloneSectionBlueprints.Load(bodyBlueprint.Id, bodyBlueprint.Text, bodyBlueprint.TrimText,
                bodyBlueprint.AppendNewLineBefore, bodyBlueprint.AppendNewLineAfter, BlueprintTypeEnum.Body);

            cloneSectionBlueprints.Load(footerBlueprint.Id, footerBlueprint.Text, footerBlueprint.TrimText,
                footerBlueprint.AppendNewLineBefore, footerBlueprint.AppendNewLineAfter, BlueprintTypeEnum.Footer);

            return cloneSectionBlueprints;
        }
    }
}
