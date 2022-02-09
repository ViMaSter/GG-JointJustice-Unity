using UnityEngine;
using System;
using UnityEngine.UI;

public class CaseSelectMenu : MonoBehaviour
{
    [SerializeField] private MenuItem _buttonPrefab;
    [SerializeField] private Transform _buttonContainer;
    [SerializeField] private Image _previewImage;
    [SerializeField] private ChapterSelectMenu _chapterSelectMenu;
    [SerializeField] private NarrativeCase[] _cases;

    /// <summary>
    /// On Awake:
    /// Subscribe back button to show and hide preview
    /// Instantiate buttons equal to number of cases
    /// Set button text
    /// Subscribe instantiated buttons to update preview image
    /// Add onClick logic to each button: either start the game or open the chapter select menu
    /// </summary>
    private void Awake()
    {
        var backButton = GetComponentInChildren<MenuItem>();
        backButton.OnItemSelect.AddListener(() => _previewImage.color = Color.black);
        backButton.OnItemDeselect.AddListener(() => _previewImage.color = Color.white);

        foreach (var narrativeCase in _cases)
        {
            var menuItem = Instantiate(_buttonPrefab, _buttonContainer);
            menuItem.Text = narrativeCase.Name;
            menuItem.OnItemSelect.AddListener(() => _previewImage.sprite = narrativeCase.PreviewImage);
            var menuOpener = menuItem.GetComponent<MenuOpener>();
            menuOpener.MenuToOpen = _chapterSelectMenu.Menu;
            ((Button)menuItem.Selectable).onClick.AddListener(() =>
            {
                if (narrativeCase.Chapters.Length == 1)
                {
                    throw new NotImplementedException("Put logic for starting game here");
                }
                
                menuOpener.OpenMenu();
                _chapterSelectMenu.Initialise(narrativeCase.Chapters, menuOpener);
            });
        }
    }
}
